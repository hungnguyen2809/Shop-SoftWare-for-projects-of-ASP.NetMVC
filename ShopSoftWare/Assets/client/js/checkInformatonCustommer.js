$("#payment").off("click").on("click", function () {
    var name = $("#name").val();
    var address = $("#address").val();
    var phone = $("#phone").val();
    var email = $("#email").val();
    var request = $("#request").val();

    if (name == "") {
        alert("Tên người thanh toán đang trống !");
    }
    else if (address == "") {
        alert("Địa chỉ không được trống !");
    }
    else if (phone == "") {
        alert("Điện thoại không được để trống !");
    }
    else if (email == "") {
        alert("Email không được để trống");
    }
    else {
        $.ajax({
            url: "/CartPayment/Payment",
            dataType: "json",
            type: "POST",
            data: {
                name: name,
                address: address,
                phone: phone,
                email: email,
                request: request
            },
            success: function (responive) {
                if (responive.status == true) {
                    window.location.href = "/thanh-toan-thanh-cong";
                }
                else {
                    window.location.href = "/thanh-toan-that-bai";
                }
            }
        });
    }
});