const Router = require('koa-router');

const homeRouter = new Router();

homeRouter.get('/', async (ctx) => {
  ctx.body = 'Hello World';
});

module.exports = homeRouter;
