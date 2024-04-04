$(() => {
    $("#postForm").validate({
        rules: {
            username: {
                required: true,
                maxlength: 10
            },
            password: {
                required: true,
                maxlength: 10
            }
        }
    });
});