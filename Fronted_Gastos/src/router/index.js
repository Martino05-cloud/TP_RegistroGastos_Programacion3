import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import AltaGastos from '../views/AltaGastos.vue'
import ListadoGastos from '../views/ListadoGastos.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/AltaGastos',
      name: 'AltaGastos',
      component: AltaGastos,
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      //component: () => import('../views/AboutView.vue'),
    },
    {
      path: '/ListadoGastos',
      name: 'ListadoGastos',
      component: ListadoGastos,
    },
  ],
})

export default router
