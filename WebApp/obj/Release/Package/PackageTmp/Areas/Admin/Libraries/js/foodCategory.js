$(document).ready(function () {
    $('.delete').on('click', function () {
        if (confirm('Bạn muốn xóa bản ghi này?')) {
            Delete($(this).data('id'));
        }
    });
});

function Delete(id) {
    $.ajax({
        type: "POST",
        data: {
            id: id
        },
        cache: false,
        async: false,
        url: "/FoodCategory/Delete/",
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