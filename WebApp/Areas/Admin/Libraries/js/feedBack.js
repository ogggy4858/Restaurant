$(document).ready(function () {
    $('.btnDisable').on('click', function () {
        let id = $(this).data('id');
        if (confirm("Bạn muốn ẩn feedback này?")) {
            disableFeedBack(id);
        }
    });

    $('#clearFeedBack').on('click', function () {
        let url = window.location.href;
        let array = url.indexOf('?');
        if (array !== -1) {
            window.location.href = url.split('?')[0];
        }
    });
});

function disableFeedBack(id) {
    $.ajax({
        type: "POST",
        data: {
            id: id
        },
        cache: false,
        async: false,
        url: "/FeedBack/DisableFeedBack/",
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