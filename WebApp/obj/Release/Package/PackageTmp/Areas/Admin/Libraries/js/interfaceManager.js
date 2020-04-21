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

    $('.btn-foodCategory-add').on('click', function () {
        if (confirm("Bạn muốn áp dụng bản ghi này")) {
            var id = $(this).data('id');
            Active(id, "FoodCategory");
        }
    });

    $('.btn-image-add').on('click', function() {
        if (confirm("Bạn muốn áp dụng bản ghi này")) {
            Active($(this).data('id'), "Image");
        }
    });

    $('.btn-image-delete').on('click', function() {
        if (confirm("Bạn muốn xóa bản ghi này")) {
            var id = $(this).data('id');
            Delete(id);
        }
    });

    $('.btn-banner-delete').on('click', function () {
        if (confirm("Bạn muốn xóa bản ghi này")) {
            var id = $(this).data('id');
            Delete(id);
        }
    });

    $('.btn-welcome-delete').on('click', function () {
        if (confirm("Bạn muốn xóa bản ghi này")) {
            var id = $(this).data('id');
            Delete(id);
        }
    });

    $('.btn-hotmenu-delete').on('click', function () {
        if (confirm("Bạn muốn xóa bản ghi này")) {
            var id = $(this).data('id');
            Delete(id);
        }
    });

    $('.btn-menu-delete').on('click', function () {
        if (confirm("Bạn muốn xóa bản ghi này")) {
            var id = $(this).data('id');
            Delete(id);
        }
    });

    $('.btn-foodCategory-delete').on('click', function () {
        if (confirm("Bạn muốn xóa bản ghi này")) {
            var id = $(this).data('id');
            Delete(id);
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

function Delete(id) {
    $.ajax({
        type: "POST",
        data: {
            id: id
        },
        cache: false,
        async: false,
        url: "/InterfaceManager/Delete/",
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