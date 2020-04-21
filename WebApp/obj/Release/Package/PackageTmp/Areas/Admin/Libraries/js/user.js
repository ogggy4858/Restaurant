$(document).ready(function () {
    $('.btn-add-admin').on('click', function () {
        if (confirm("Bạn muốn thêm người này làm admin?")) {
            let id = $(this).data('id');
            addAdmin(id);
        }
    });

    $('.btn-remove-admin').on('click', function () {
        if (confirm("Bạn muốn quyền admin của người này")) {
            let id = $(this).data('id');
            removeAdmin(id);
        }
    });

});

function removeAdmin(id) {
    $.ajax({
        type: "POST",
        data: {
            id: id
        },
        cache: false,
        async: false,
        url: "/User/RemoveAdmin/",
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

function addAdmin(id) {
    $.ajax({
        type: "POST",
        data: {
            id: id
        },
        cache: false,
        async: false,
        url: "/User/AddAdmin/",
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