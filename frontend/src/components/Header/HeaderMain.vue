<template>
  <div class="header-block">
    <header class="d-flex flex-wrap justify-content-center py-3 header-width">
      <a href="/" class="d-flex align-items-center mb-5 ml-5 mb-md-0 me-md-auto link-body-emphasis text-decoration-none"
        v-if="!props.isFromHome">
        <div class="fs-4 text-light">
          <div class="pl-2">
            Моя
          </div>
          <div style="margin-top: -24px;">
            Россия
          </div>
        </div>
      </a>
      <div class="d-flex align-items-center mb-5 ml-5 mb-md-0 me-md-auto link-body-emphasis text-decoration-none" v-else
        @click="() => emit('showHome')" style="cursor: pointer;">
        <div class="fs-4 text-light">
          <div class="pl-2">
            Моя
          </div>
          <div style="margin-top: -24px;">
            Россия
          </div>
        </div>
      </div>

      <ul class="nav nav-pills">
        <li class="nav-item"><router-link class="link-body-emphasis text-decoration-none fs-4 mr-5"
            to="/route">маршруты</router-link></li>
        <li class="nav-item"><router-link class="link-body-emphasis text-decoration-none fs-4 mr-5"
            to="/locationCard">cоздать локацию</router-link></li>
        <li class="nav-item"><router-link class="link-body-emphasis text-decoration-none fs-4 mr-5"
            to="/routePoint">cоздать маршрут</router-link></li>
        <li class="nav-item"><router-link class="link-body-emphasis text-decoration-none fs-4 mr-5" to="/routePoint">о
            нас</router-link></li>
        <li class="nav-item"><router-link class="link-body-emphasis text-decoration-none fs-4 mr-5"
            to="/routePoint">контакты</router-link></li>
      </ul>
    </header>
  </div>
</template>

<script setup lang="ts">
import { defineProps, defineEmits } from "vue"

const props = withDefaults(defineProps<{
  isFromHome: boolean
}>(),
  {
    isFromHome: false
  })

const emit = defineEmits(["showHome"])
</script>

<style lang="scss" scoped>
.header-block {
  width: 100%;
  height: 70px;
  background-color: rgba(256, 256, 256, 0.3);
  background-color: rgba(120, 120, 120, 0.4);
  position: absolute;
  backdrop-filter: blur(3px);
  z-index: 9999;
}

.header-width {
  height: 100%;
  width: 100%;
  position: relative;
}
</style>