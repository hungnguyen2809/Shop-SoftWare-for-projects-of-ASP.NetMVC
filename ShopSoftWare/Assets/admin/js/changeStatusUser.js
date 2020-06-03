var user = {
    init: function () {
        //Khởi tạo
        user.registerEvent();
    },
    registerEvent: function () {
        //bắt sự kiện khi click vòa trạng thái cảu user nó sẽ thay đổi ngay lập tức
        $('.btn-active').off('click').on('click', function (e) {
            //gọi tới nó bằng tên class với dấu chấm đầu câu -> ta sẽ tắt nó đi trước, rồi mới gọi lại
            e.preventDefault();//để không bắt sự kiện click vào nhẩy sang trang mặc đinh là dấu # của thẻ a
            //Tiếp theo là ta cần lấy id của phần tử mà ta bấm vào, do đó hiện tại  ta đang dùng ở ngay trong chính cái thẻ a này
            //đo đó ta tuyền this vào và lấy data với tham số tuyền vào là id , để thể hiện là tất cả những cái đằng sau data-..()
            //là tên thuộc tính ta tự đặt với HTML 5. trong này thì là ta cần lấy id nên ta dùng id.
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: '/ADUser/ChangeStatusUser',
                data: { id: id },
                dataType: 'json',
                type: 'POST',
                success: function (response) {
                    //response chính là đối tượng mà hàm ChangeStatusUser trả về là chuỗi json với name là status
                    if (response.status == true) {
                        //nếu bằng true thì ta gán  text hiện tại của đối tượng đag thao tác lại.
                        btn.text('Kích hoạt');
                    }
                    else {
                        btn.text('Khóa');
                    }

                }
            });
        });

    }
}

user.init();