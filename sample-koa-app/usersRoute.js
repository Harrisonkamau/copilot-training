const Router = require('koa-router');
const fs = require('fs');
const path = require('path');

const usersRouter = new Router();

usersRouter.get('/users', ctx => {
  const usersPath = path.join(__dirname, 'users.json');
  const usersData = fs.readFileSync(usersPath, 'utf-8');
  ctx.type = 'application/json';
  ctx.body = usersData;
});

module.exports = usersRouter;
