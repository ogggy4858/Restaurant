$(document).ready(function () {
    PostFoodCategoryId(null);
    $('.btn-submit').on('click', function () {
        var id = $(this).data('id');
        removeClass();
        $(this).removeClass('btn-white');
        $(this).addClass('btn-primary');
        PostFoodCategoryId(id);
    });
});

function removeClass() {
    for (let i = 0; i < $('.btn-submit').length; i++) {
        $($('.btn-submit')[i]).removeClass('btn-primary');
        $($('.btn-submit')[i]).addClass('btn-white');
    }
}

function PostFoodCategoryId(id) {
    $.ajax({
        type: "POST",
        data: {
            foodCategoryId: id
        },
        cache: false,
        async: false,
        url: "/Home/ReloadMenu/",
        dataType: 'json',
        success: function (resp) {
            if (resp.Status) {
                appendItemsToCol1(resp.Data);
                appendItemsToCol2(resp.Data);
            }
            else {
                alert(resp.Message);
            }
        }
    });
}

function appendItemsToCol1(data) {
    let html = '';
    $('#col1').html('');
    for (let i = 0; i < Math.ceil(data.length / 2); i++) {
        html += '<div class="pricing-entry d-flex ftco-animate fadeInUp ftco-animated">';
        html += '<div class="img" style="background-image: url(../../Areas/Admin/Libraries/images/'+ data[i].Image +');"></div>';
        html += '<div class="desc pl-3">';
        html += '<div class="d-flex text align-items-center">';
        html += '<h3><span>'+ data[i].Name +'</span></h3>';
        html += '</div>';
        html += '<div class="d-block">';
        html += '<p>'+ data[i].Description +'</p>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
    }

    $('#col1').append(html);
}

function appendItemsToCol2(data) {
    let html = '';
    $('#col2').html('');
    for (let i = Math.ceil(data.length / 2); i < data.length; i++) {
        html += '<div class="pricing-entry d-flex ftco-animate fadeInUp ftco-animated">';
        html += '<div class="img" style="background-image: url(../../Areas/Admin/Libraries/images/' + data[i].Image + ');"></div>';
        html += '<div class="desc pl-3">';
        html += '<div class="d-flex text align-items-center">';
        html += '<h3><span>' + data[i].Name + '</span></h3>';
        html += '</div>';
        html += '<div class="d-block">';
        html += '<p>' + data[i].Description + '</p>';
        html += '</div>';
        html += '</div>';
        html += '</div>';
    }

    $('#col2').append(html);
}