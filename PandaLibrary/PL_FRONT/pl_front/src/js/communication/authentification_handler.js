import decode from "jwt-decode";
const ACCESS_TOKEN_KEY = "access_token";
const REFRESH_TOKEN_KEY = "refresh_token";
const helper = require("./api_request");

export function getAccessToken() {
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}

export function getRefreshToken() {
  return localStorage.getItem(REFRESH_TOKEN_KEY);
}

export function setAccessToken(accessToken) {
  localStorage.setItem(ACCESS_TOKEN_KEY, accessToken);
}

export function getIdUserFromToken() {
  const token = decode(getAccessToken());
  return token.nameid;
}

export function setRefreshToken(refreshToken) {
  localStorage.setItem(REFRESH_TOKEN_KEY, refreshToken);
}

function getTokenExpirationDate(encodedToken) {
  let token = decode(encodedToken);
  if (!token.exp) {
    return null;
  }

  return new Date(0).setUTCSeconds(token.exp);
}

export function isTokenExpired(token) {
  return getTokenExpirationDate(token) < new Date();
}

export function hasRoleInToken(role) {
  let token = decode(getAccessToken());
  return token.role.includes(role);
}

export function disconnect(instance) {
  let data = {
    token: getRefreshToken(),
    client_id: instance.clientId,
    client_secret: instance.clientSecret,
  };
  helper.request("/v1/token/revoke", "post", data, false).then(() => {
    clearStorage(instance);
    instance.$router.push({ name: "login" });
  });
}

export function clearStorage() {
  localStorage.clear();
}
