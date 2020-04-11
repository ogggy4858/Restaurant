$(document).ready(function () {
    $('#submit').on('click', function () {
        var customerName = $('#customerName').value;
        var phone = $('#phone').value;
        var title = $('#title').value;
        var message = $('#message').value;

        feedBack(customerName, phone, title, message);
    });
});


function feedBack(customerName, phone, title, message) {
    if (!validate(title)) {
        alert('Tiêu đề là bắt buộc');
        return;
    }

    $.ajax({
        type: "POST",
        data: {
            customerName: customerName,
            phone: phone,
            title: title,
            message: message
        },
        cache: false,
        async: false,
        url: "/Food/FeedBack/",
        dataType: 'json',
        success: function (resp) {
            if (resp.Status) {
                alert(true);
            }
            else {
                alert(resp.Message);
            }
        }
    });
}

function validate(title) {
    if (title === null || title === undefined || title === '') {
        return false;
    }
    return true;
}