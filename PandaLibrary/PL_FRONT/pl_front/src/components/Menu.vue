<template>
  <div id="nav" class="font-poppins w-full font-bold p-8 flex flex-row justify-center items-center">
    <router-link to="/" class="min-w-100">Librairies</router-link> |
    <router-link to="/about" class="min-w-100">Livres</router-link> 
    <img id="accueil" alt="Accueil" src="../assets/img/LOGO_FDBLANC.svg" class="max-h-50 min-h-150" />
    <router-link to="/login" class="min-w-100">Utilisateurs</router-link> |
    <router-link to="/login" class="min-w-100">Stocks</router-link>
  </div>
</template>

<style>
#nav a.router-link-exact-active {
  color: #42b983;
}

#accueil {
    margin-top: -60px;
}

</style>
