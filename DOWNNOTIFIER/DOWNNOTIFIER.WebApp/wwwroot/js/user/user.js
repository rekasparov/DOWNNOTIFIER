$(() => {
    remove = (title, url) => {
        $(modalTitle).text(title);
        $(modalBtnRemove).attr('href', url);
        $(modalRemoveConfirm).modal('show');
    };
});