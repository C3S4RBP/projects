angular
    .module('marvelmodule')
    .config(function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/home");
        $stateProvider
            .state('home', {
                url: '/home',
                views: {
                    'header': {
                        component: 'headerComponent'
                    },
                    'list': {
                        component: 'listComponent'
                    },
                    'favorites': {
                        component: 'favoritesComponent'
                    }
                }
            });
    })

    // .config(['$httpProvider', '$provide', function ($httpProvider, $provide) {
    //     $provide.factory('httpInjector', ['SessionService', function (SessionService) {
    //         return {
    //             request: function (config) {
    //                 if (!SessionService.isAnonymus) {
    //                     config.headers['x-session-token'] = SessionService.token;
    //                 }
    //                 return config;
    //             },
    //             requestError: function (rejection) {
    //                 if (canRecover(rejection)) {
    //                     return responseOrNewPromise
    //                 }
    //                 return $q.reject(rejection);
    //             },
    //         };
    //     }])

    //     $httpProvider.interceptors.push('sessionInjector');
    // }]);