const request = require('supertest');
const Koa = require('koa');
const fs = require('fs');
const path = require('path');
const usersRouter = require('./usersRoute');

const usersJsonPath = path.join(__dirname, 'users.json');
const mockUsers = [
  { id: 1, name: 'Alice Smith', email: 'alice@example.com' },
  { id: 2, name: 'Bob Johnson', email: 'bob@example.com' }
];

beforeAll(() => {
  fs.writeFileSync(usersJsonPath, JSON.stringify(mockUsers));
});

describe('Users Route', () => {
  let app;
  beforeAll(() => {
    app = new Koa();
    app.use(usersRouter.routes());
    app.use(usersRouter.allowedMethods());
  });

  it('GET /users should return users.json as JSON', async () => {
    const res = await request(app.callback()).get('/users');
    expect(res.status).toBe(200);
    expect(res.type).toBe('application/json');
    expect(JSON.parse(res.text)).toEqual(mockUsers);
  });
});

afterAll(() => {
  fs.unlinkSync(usersJsonPath);
});
