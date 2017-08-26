window.gwd = window.gwd || {};
gwd.onCharacterSelected = function (event) {
    var id = event.detail.id;
    document.getElementById('char_index').value = id;
};
gwd.onPetSelected = function (event) {
    var id = event.detail.id;
    //alert('pet index ' + id + ' selected');
};

gwd.actions.events.registerEventHandlers = function (event) {
    gwd.actions.events.addHandler('gwd-swipegallery_1', 'frameshown', gwd.onCharacterSelected, false);
};
gwd.actions.events.deregisterEventHandlers = function (event) {
    gwd.actions.events.removeHandler('gwd-swipegallery_1', 'frameshown', gwd.onCharacterSelected, false);
};
document.addEventListener("DOMContentLoaded", gwd.actions.events.registerEventHandlers);
document.addEventListener("unload", gwd.actions.events.deregisterEventHandlers);