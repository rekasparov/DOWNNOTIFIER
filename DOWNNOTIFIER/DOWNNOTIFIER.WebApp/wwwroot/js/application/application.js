$(() => {
    $("#postForm").validate({
        rules: {
            name: {
                required: true,
                maxlength: 35
            },
            url: {
                required: true,
                maxlength: 20
            },
            intervalTime: "required"
        }
    });

    remove = (title, url) => {
        $(modalTitle).text(title);
        $(modalBtnRemove).attr('href', url);
        $(modalRemoveConfirm).modal('show');
    };
});