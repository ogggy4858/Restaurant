$(document).ready(function () {
    $('#image').on('change', function () {
        readURL(this, '#imageDisplay');
    });

    $('#imageCreate').on('change', function () {
        $('#imageDisplayCreate').removeAttr('hidden');
        readURL(this, '#imageDisplayCreate');
    });

    $('.delete').on('click', function () {
        if (confirm('Bạn muốn xóa bản ghi này?')) {
            Delete($(this).data('id'));
        }
    });
});

function readURL(input, at) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(at).attr('src', e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function Delete(id) {
    $.ajax({
        type: "POST",
        data: {
            id: id
        },
        cache: false,
        async: false,
        url: "/Food/Delete/",
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