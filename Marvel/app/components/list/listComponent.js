(function () {
    'use strict';
    angular
        .module('listmodule', [])
        .component('listComponent', {
            templateUrl: 'app/components/list/view/list.view.html',
            controller: 'list.controller as listCtrl',
            controllerAs: 'listCtrl || $ctrl'
        });
})();