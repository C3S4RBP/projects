angular.module('homemodule')
    .constant('home.constants', constants())
    .constant('home.constantsEndpoint', constantsEndpoint())

function constants() {
    return {

    }
}

function constantsEndpoint() {
    return {
        server: 'https://gateway.marvel.com:443',
        key: 'cdc2b99b654e9213cb0e89f287559f16',
        getCharacter: '{server}/v1/public/characters?nameStartsWith={name}&limit={max}&offset={min}&apikey={key}'
    }
}