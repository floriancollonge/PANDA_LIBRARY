import axios from "axios";
import { targets } from "@/js/enums/targets";
import * as auth from "./authentification_handler";

export function request(uri, verb, data, authorizedResource, target) {
  let headers = {};
  if (authorizedResource) {
    headers = {
      Authorization: "Bearer " + auth.getAccessToken(),
    };
  }
  document.body.style.cursor = "wait";
  let url = getUrl(target);
  let respType = "json";

  return axios({
    method: verb,
    url: url,
    headers: headers,
    data: data,
    responseType: respType,
  })
    .then(function (response) {
      document.body.style.cursor = "default";
      return response;
    })
    .catch(function (err) {
      document.body.style.cursor = "default";
      throw err;
    });
}

export function refreshToken(instance) {
  try {
    if (!auth.getRefreshToken()) {
      auth.clearStorage(instance);
      instance.$router.push({ name: "login" });
    }
    let refreshDatas = {
      refresh_token: auth.getRefreshToken(),
      client_id: instance.$whitelabel.clientId,
      client_secret: instance.$whitelabel.clientSecret,
      id_user: auth.getIdUserFromToken(),
      grant_type: "token",
    };

    return request("/v1/gate/token", "put", refreshDatas, false)
      .then(function (response) {
        auth.setRefreshToken(response.data.refresh_token);
        auth.setAccessToken(response.data.access_token);
      })
      .catch(function () {
        auth.disconnect(instance);
      });
  } catch {
    auth.clearStorage(instance);
    instance.$router.push({ name: "login" });
  }
}

function getUrl(target) {
  switch (target) {
    case targets.Library:
      return process.env.VUE_APP_LIBRARY_URL;
    case targets.Order:
      return process.env.VUE_APP_ORDER_URL;
    case targets.Reference:
      return process.env.VUE_APP_REFERENCE_URL;
    case targets.Sale:
      return process.env.VUE_APP_SALE_URL;
    case targets.Stock:
      return process.env.VUE_APP_STOCK_URL;
    case targets.User:
      return process.env.VUE_APP_USER_URL;
    case targets.Barrier:
      return process.env.VUE_APP_BARRIER_URL;
    case targets.BI:
      return process.env.VUE_APP_BI_URL;
  }
}
