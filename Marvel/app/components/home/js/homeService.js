(function () {
    'use strict';

    angular
        .module('homemodule')
        .service('home.service', homeService);

    homeService.$inject = ['$http', 'home.constantsEndpoint', 'marvel.service'];
    function homeService($http, CONSTANT, marvelService) {
        this.getCharacter = getCharacter;
        function getCharacter(params) {
            var url = marvelService.formatear(params, CONSTANT, 'getCharacter');
            return $http.get(url)
                .then(function succes(response) {
                    return response;
                }, function error(error) {
                    return error;
                })
        }
    }
})();