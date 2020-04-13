$(document).ready(function () {
    $('.set-active').on('click', function () {
        if (confirm("Bạn sử dụng menu này?")) {
            setActive($(this).data('id'), "Image");
        }
    });
});

function setActive(id, categoryName) {
    $.ajax({
        type: "POST",
        data: {
            id: id,
            categoryName: categoryName
        },
        cache: false,
        async: false,
        url: "/InterfaceManager/Active/",
        dataType: 'json',
        success: function (resp) {
            if (resp.Status) {
                location.reload();
            }
            else {
                alert(resp.Message);
            }
        }
    });
}