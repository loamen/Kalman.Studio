'use strict';

module.exports = app => {
  app.resources('users', '/users', app.controller.user);
};
