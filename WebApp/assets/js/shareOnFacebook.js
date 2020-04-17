$(document).ready(function () {
    $('#facebook').on('click', function () {
        let url = window.location.href;
        share_fb(url);
    });

    new InstagramFeed({
        'username': 'instagram',
        'container': "#instagram-feed-demo"
    });
});



function share_fb(url) {
    window.open('https://www.facebook.com/sharer/sharer.php?u=' + url, 'facebook-share-dialog', "width=626, height=436");
}