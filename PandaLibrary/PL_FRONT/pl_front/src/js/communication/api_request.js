import axios from "axios"
import * as auth from "./authentification_handler"

export function request(
  uri,
  verb,
  data,
  authorizedResource,
  target,
  responseType,
  cancelTokenSource
) {
  var headers = {}
  if (authorizedResource) {
    var headers = {
      Authorization: auth.getAuthHeaderFromToken(auth.getAccessToken())
    }
  }
  document.body.style.cursor = "wait"
  var url = ""
  var respType = "json"
  if (responseType != "" && responseType != null) {
    respType = responseType
  }

  return axios({
    method: verb,
    url: url,
    headers: headers,
    data: data,
    responseType: respType,
    cancelToken: cancelTokenSource?.token
  })
    .then(function (response) {
      document.body.style.cursor = "default"
      return response
    })
    .catch(function (err) {
      document.body.style.cursor = "default"
      // we add this event, to stop the loader every time there is an error in a http request, so we do not have to do this in every component calling this method
      EventBus.$emit("loading", false)
      throw err
    })
}

export function refreshToken(instance) {
  try {
    if (!auth.getRefreshToken()) {
      auth.clearStorage(instance)
      instance.$router.push({ name: "login" })
    }
    var refreshDatas = {
      refresh_token: auth.getRefreshToken(),
      client_id: instance.$whitelabel.clientId,
      client_secret: instance.$whitelabel.clientSecret,
      id_user: auth.getIdUserFromToken(),
      grant_type: "token"
    }

    return request("/v1/gate/token", "put", refreshDatas, false)
      .then(function (response) {
        auth.setRefreshToken(response.data.refresh_token)
        auth.setAccessToken(response.data.access_token)
      })
      .catch(function (err) {
        auth.disconnect(instance)
      })
  } catch {
    auth.clearStorage(instance)
    instance.$router.push({ name: "login" })
  }
}