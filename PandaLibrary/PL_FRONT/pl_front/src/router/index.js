import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "default",
    component: () => import("../views/DefaultProfile.vue"),
    children: [
      {
        path: "/",
        name: "Home",
        component: () => import("../views/Home.vue"),
      },
      {
        path: "/login",
        name: "Login",
        component: () => import("../views/Login.vue"),
      },
      {
        path: "/about",
        name: "About",
        component: () => import("../views/About.vue"),
      },
    ]
  },
  {
    path: "/",
    name: "Profile",
    component:  () => import("../views/profile/Profile.vue"),
    children: [
      {
        path: "/home",
        name: "Accueil",
        component:  () => import("../views/profile/Accueil.vue"),
      },
    ]
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
