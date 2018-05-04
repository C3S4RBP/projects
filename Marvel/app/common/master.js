(function () {
    'use strict';

    angular
        .module('marvelmodule')
        .service('marvel.service', marvelService);

    marvelService.$inject = ['$http'];
    function marvelService($http, CONSTANT) {
        this.formatear = formatear;
        function formatear(cadena, arreglo, service) {
            return arreglo[service].replace('{server}', arreglo.server).replace('{key}', arreglo.key).replace('{name}', cadena.name).replace('{max}', cadena.max).replace('{min}', cadena.min);
        }
    }
})();