import RouteViewVue from '@/views/RouteView.vue'
import RoutePointView from '@/views/RoutePointView.vue'
import LocationCardView from '@/views/LocationCardView.vue'
import HomeView from '@/views/HomeView.vue'
import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: '',
      component: HomeView
    },
    {
      path: '/route',
      name: 'route',
      component: RouteViewVue
    },
    {
      path: "/routePoint",
      name: "routePoint",
      component: RoutePointView
    },
    {
      path: '/locationCard',
      name: 'locationCard',
      component: LocationCardView
    }
    // {
    //   path: '/about',
    //   name: 'about',
    //   // route level code-splitting
    //   // this generates a separate chunk (About.[hash].js) for this route
    //   // which is lazy-loaded when the route is visited.
    //   component: () => import('../views/AboutView.vue')
    // }
  ]
})

export default router
