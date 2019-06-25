(function(root, factory) {
    root.ModalService = factory(root);
})(window, function(root) {
    var createModal = function(htmlModalId, templateElement, bindingFunction) {
        $(htmlModalId).html(templateElement);
        if (typeof (bindingFunction) === "function") {
            bindingFunction();
        }
    }

    var showModal = function(htmlModalId) {
        $(htmlModalId).modal('show');
    }

    var showAndCreateModal = function(htmlModalId, templateElement, bindingFunction)
    {
        createModal(htmlModalId, templateElement, bindingFunction);
        showModal(htmlModalId);
    }
    return {
        createModal: createModal,
        showModal: showModal,
        showAndCreate: showAndCreateModal
    }
});