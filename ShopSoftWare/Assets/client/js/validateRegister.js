function checkUsername(str){
   return str.length >= 5 && str.length <= 20;
}

function checkRepass(pass1, pass2){
    return pass1 === pass2;
}

function checkLength(str) {
    if (str.length > 1) {
        return true;
    }
    else {
        return false;
    }
}

function checkEmail(str){
    var reg = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return(reg.test(str));
}

$(document).ready(function(){
    $('#username').change(function(){
        var value = $(this).val().trim();
        if(!checkUsername(value)){
            $('.errUsername').html("Tài khoản tối thiểu 5 ký tự và Tối đa 20 ký tự");
        }
        else{
            $('.errUsername').html("");
        }
    });

    $('#name').change(function(){
        var value = $(this).val().trim();
        if(!checkLength(value)){
            $('.errName').html("Không được để trống !");
        }
        else{
            $('.errName').html("");
        }
    });

    $('#pass').change(function(){
        var value = $(this).val().trim();
        if(!checkLength(value)){
            $('.errPass').html("Không được để trống !");
        }
        else{
            $('.errPass').html("");
        }
    });

    $('#repass').change(function(){
        var value = $(this).val().trim();
        if(!checkLength(value)){
            $('.errRepass').html("Không được để trống !");
        }
        else{
            $('.errRepass').html("");
        }
    });

    $('#repass').change(function(){
        var value1 = $(this).val().trim();
        var value2 = $('#pass').val().trim();
        if(!checkRepass(value1, value2)){
            $('.errRepass').html("Mật khẩu nhập lại không đúng.");
        }
        else{
            $('.errRepass').html("");
        }
    });

    $('#address').change(function(){
        var value = $(this).val().trim();
        if(!checkLength(value)){
            $('.errAddress').html("Không được để trống !");
        }
        else{
            $('.errAddress').html("");
        }
    });

    $('#phone').change(function(){
        var value = $(this).val().trim();
        if(!checkLength(value)){
            $('.errPhone').html("Không được để trống !");
        }
        else{
            $('.errPhone').html("");
        }
    });

    $('#email').change(function(){
        var value = $(this).val().trim();
        if(!checkEmail(value)){
            $('.errEmail').html("Email không đúng định dạng !");
        }
        else{
            $('.errEmail').html("");
        }
    });
});
