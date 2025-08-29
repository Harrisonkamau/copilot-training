/**
 * Sets up a simple Koa.js server with routing.
 *
 * - GET /users: Returns the contents of users.json as JSON.
 * - GET /: Returns "Hello World".
 *
 * @fileoverview Simple Koa.js server with basic routing.
 */

// setup a simple koa.js server

const Koa = require('koa');
const homeRouter = require('./homeRoute');
const usersRouter = require('./usersRoute');

const app = new Koa();

app.use(homeRouter.routes());
app.use(homeRouter.allowedMethods());
app.use(usersRouter.routes());
app.use(usersRouter.allowedMethods());

const PORT = process.env.PORT || 3000;
app.listen(PORT);
console.log(`Server running on http://localhost:${PORT}`);
