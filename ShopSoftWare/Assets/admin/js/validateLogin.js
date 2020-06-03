$(document).ready(function(){

    function isUser(user){
        return user.length < 5;
    }

    function isPass(pass){
        return pass.length < 5;
    }

    $('#username').change(function(){
        var user = $(this).val().trim();
        if(isUser(user)){
            $('.err-user').html('Độ dài tối thiểu 5 ký tự');
        }
        else{
            $('.err-user').html('');
        }
    });

    $('#password').change(function(){
        var pass = $(this).val().trim();
        if(isPass(pass)){
            $('.err-pass').html('Độ dài tối thiểu 5 ký tự');
        }
        else{
            $('.err-pass').html('');
        }
    });

    $('#check').click(function(){
        if ($('#password').attr('type') == 'text') {
            $('#password').attr('type', 'password');
        } else {
            $('#password').attr('type', 'text');
        }
    });
    
});
