$(document).ready(function() {
    $('.set-active').on('click', function() {
        if (confirm("Bạn sử dụng menu này?")) {
            setActive($(this).data('id'));
        }
    });
});

function setActive(id) {
    $.ajax({
        type: "POST",
        data: {
            id: id
        },
        cache: false,
        async: false,
        url: "/HotMenu/SetActive/",
        dataType: 'json',
        success: function(resp) {
            if (resp.Status) {
                location.reload();
            }
            else {
                alert(resp.Message);
            }
        }
    });
}