window.selectOnFocus = function (element) {
    if (element) {
        element.addEventListener("focus", function () {
            element.select();
        });
    }
};
