$(document).ready(function () {
    $('.btn-banner-add').on('click', function () {
        if (confirm("Bạn muốn áp dụng bản ghi này")) {
            var id = $(this).data('id');
            Active(id, "Banner");
        }
    });

    $('.btn-welcome-add').on('click', function () {
        if (confirm("Bạn muốn áp dụng bản ghi này")) {
            var id = $(this).data('id');
            Active(id, "Welcome");
        }
    });

    $('.btn-hotmenu-add').on('click', function () {
        if (confirm("Bạn muốn áp dụng bản ghi này")) {
            var id = $(this).data('id');
            Active(id, "HotMenu");
        }
    });

    $('.btn-menu-add').on('click', function() {
        if (confirm("Bạn muốn áp dụng bản ghi này")) {
            var id = $(this).data('id');
            Active(id, "Menu");
        }
    });
});


function Active(id, categoryName) {
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