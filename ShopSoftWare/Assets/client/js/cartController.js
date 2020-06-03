function checkQuantity(arr) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i].quantity == "" || arr[i].quantity == "0") {
            return false;
        }
    }
    return true;
}

var cart = {
    init: function () {
        cart.regEvent();
    },

    regEvent: function () {
        $('#btnContinue').off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/trang-chu";
        });

        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity'); //danh sách các đối tượng item mà nó lặp qua có tên trong class là txtQuantity
            var cartList = [];
            //lặp qua từng phần tử để lấy giá trị
            $.each(listProduct, function (i, item) {
                cartList.push({
                    quantity: $(item).val(), //item.val() lấy ra giá trị nằm trong thuộc tính value của từng item một trong đây là số lượng
                    product: {
                        IDProduct: $(item).data('id') //lấy giá trị id từ thuộc tính tự đặt là data-id
                    }
                });
            });

            if (checkQuantity(cartList)) {
                //đẩy nó lên controller
                $.ajax({
                    url: '/CartPayment/Update', //đều hướng nó về controller
                    data: { cartModel: JSON.stringify(cartList) }, //data là dữ liệu mà ta đã ép chuỗi Json
                    dataType: 'json',
                    type: 'POST',
                    success: function (responsive) {
                        if (responsive.status == true) {
                            //nếu thành công thì nhẩy về giỏ hàng 
                            window.location.href = "/gio-hang"
                        }
                        else {
                            alert("Lỗi giao dịch !")
                        }
                    }
                });
            }
            else {
                alert("Trong giỏ hàng của bạn có sản phẩm có số lượng bằng không hoặc đang để trống.\nNếu bạn không muốn mua sản phẩm đó vui lòng xóa sản phẩm đó đi !");
            }         
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            //đẩy nó lên controller
            $.ajax({
                url: '/CartPayment/Delete', //đều hướng nó về controller      
                data: { id: $(this).data('id') },
                dataType: 'json',
                type: 'POST',
                success: function (responsive) {
                    if (responsive.status == true) {

                        window.location.href = "/gio-hang"
                    }
                    else {
                        alert("Lỗi giao dịch !")
                    }
                }
            });
        });
    }
}

cart.init();