const request = require('supertest');
const Koa = require('koa');
const homeRouter = require('./homeRoute');

describe('Home Route', () => {
  let app;
  beforeAll(() => {
    app = new Koa();
    app.use(homeRouter.routes());
    app.use(homeRouter.allowedMethods());
  });

  it('GET / should return Hello World', async () => {
    const res = await request(app.callback()).get('/');
    expect(res.status).toBe(200);
    expect(res.text).toBe('Hello World');
  });
});
