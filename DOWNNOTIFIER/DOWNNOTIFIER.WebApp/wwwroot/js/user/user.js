$(() => {
    $("#postForm").validate({
        rules: {
            name: {
                required: true,
                maxlength: 35
            },
            surname: {
                required: true,
                maxlength: 35
            },
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

    remove = (title, url) => {
        $(modalTitle).text(title);
        $(modalBtnRemove).attr('href', url);
        $(modalRemoveConfirm).modal('show');
    };
});