$(() => {
    remove = (title, url) => {
        $(modalTitle).text(title);
        $(modalTitle).attr('href', url);
        $(modalRemoveConfirm).modal('show');
    };
});