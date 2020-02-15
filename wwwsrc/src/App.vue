<template>
  <div class="app grid" id="app">
    <router-view />
  </div>
</template>

<style>
::-webkit-scrollbar {
  display: none;
}
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #211a21;
}
#nav {
  padding: 30px;
}
#nav a {
  font-weight: bold;
  color: #211a21;
}
</style>