import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'CommentManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44372/',
    redirectUri: baseUrl,
    clientId: 'CommentManagement_App',
    responseType: 'code',
    scope: 'offline_access CommentManagement',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44372',
      rootNamespace: 'JS.Abp.CommentManagement',
    },
    CommentManagement: {
      url: 'https://localhost:44370',
      rootNamespace: 'JS.Abp.CommentManagement',
    },
  },
} as Environment;
