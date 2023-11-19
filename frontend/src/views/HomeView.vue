<template>
    <div style="height: 100%;">
        <HeaderMainVue v-if="!hideElements" :is-from-home="true" @show-home="hideRoutes"/>
        <div class="d-flex d-inline-flex header-block-local">
            <a href="/" class="link-body-emphasis text-decoration-none mr-5">
                <div class="fs-4 text-light">
                    <div class="pl-2">
                        Моя
                    </div>
                    <div style="margin-top: -24px;">
                        Россия
                    </div>
                </div>
            </a>
            <ul class="nav nav-pills mt-2 navigation" style="margin-bottom: 7em;">
                <li class="nav-item"><router-link class="link-light text-decoration-none fs-4 mr-5" to="/route">О
                        НАС</router-link></li>
                <li class="nav-item"><router-link class="link-light text-decoration-none fs-4"
                        to="/locationCard">КОНТАКТЫ</router-link>
                </li>
            </ul>
        </div>
        <div class="float-left home-text-block">
            <div class="home-text">Создайте</div>
            <div class="home-text">уникальный маршрут</div>
            <div class="home-text">по своему городу</div>
            <div class="row gap-4 mt-5">
                <div>
                    <div @click="showRoutes" class="btn active btn-xlg btn-light rounded-pill" to="/route">Посмотреть локации и
                        маршруты</div>
                </div>
                <div>
                    <router-link class="btn active btn-light rounded-pill" to="/locationCard">Создать локацию</router-link>
                </div>
                <div>
                    <router-link class="btn active btn-light rounded-pill" to="/routePoint">Создать маршрут</router-link>
                </div>
            </div>
        </div>
        <div class="build line-animation build-line"><img src="@/assets/imgs/Build1.png" /></div>
        <div class="build line-animation build-line" style="animation-delay: 1s;"><img src="@/assets/imgs/build2.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 2s;"><img src="@/assets/imgs/build3.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 3s;"><img src="@/assets/imgs/build4.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 4s;"><img src="@/assets/imgs/build5.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 5s;"><img src="@/assets/imgs/build6.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 6s;"><img src="@/assets/imgs/build2.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 7s;"><img src="@/assets/imgs/build3.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 8s;"><img src="@/assets/imgs/build4.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 9s;"><img src="@/assets/imgs/build5.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 10s;"><img src="@/assets/imgs/build6.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 11s;"><img src="@/assets/imgs/build2.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 12s;"><img src="@/assets/imgs/build3.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 13s;"><img src="@/assets/imgs/build4.png" />
        </div>
        <div class="build line-animation build-line" style="animation-delay: 14s;"><img src="@/assets/imgs/build5.png" />
        </div>
    </div>
    <div class="ya-block" :style="showRoutesCard ? '--button-bg-color:100vw':''">
        <RouteView :hide-elements="hideElements" />
    </div>
</template>

<script setup lang="ts">
import HeaderMainVue from '@/components/Header/HeaderMain.vue';
import RouteView from './RouteView.vue';
import {ref} from "vue";
import axios from "axios";

const loadData = async () => {
    console.log(await axios.get(`/Event`))
}

loadData();
const hideElements = ref(true);
const showRoutesCard = ref(false);
const showRoutes = () => {
    showRoutesCard.value = !showRoutesCard.value;
    setTimeout(() => {
        hideElements.value = !hideElements.value
    }, 500);
}
const hideRoutes = () => {
    hideElements.value = !hideElements.value
    showRoutesCard.value = !showRoutesCard.value;
}
</script>

<style lang="scss" scoped>
.home-block {
    width: 50%;
}

.header-block-local {
    padding-top: 2em;
    position: absolute;
    z-index: 85;
    padding-left: 3em;
    padding-right: 3em;
    width: 50vw;
}

.navigation {
    display: flex;
    justify-content: end;
    // position: relative;
    // float: right;
    
    width: 100%;
}

.ya-block {
    --button-bg-color: 50vw;
    position: absolute;
    width: var(--button-bg-color);
    height: 100vh;
    right: 0;
    transition: width 0.25s ease-in-out;
    z-index: 85;
}
.home {
    background: url("../assets/imgs/homeImage.png") no-repeat;
    background-size: cover;
    width: 100%;
    height: 100vh;
    position: relative;
    z-index: 90;
}

.home-text-block {
    background: url("../assets/imgs/homeImage.png") no-repeat;
    background-size: cover;
    width: 50%;
    height: 100vh;
    padding-left: 5em;
    padding-top: 7em;
    z-index: 80;
    position: relative;
}

.line-animation {
    animation-name: slide;
    animation-duration: 15s;
    animation-iteration-count: infinite;
    animation-timing-function: linear;
}

.line-animation:hover {
    cursor: pointer;
}

.home-text {
    color: white;
    font-size: 40px;
    font-weight: 600;
}

.build {
    margin-right: calc(50vw - 15em);
    width: 150px;
    height: 150px;
    justify-content: center;
    display: flex;
    align-items: center;
    z-index: 80;
}

.build img {
    max-width: 100%;
    max-height: 100%;
}

.build-line {
    bottom: 0;
    right: 0;
    position: absolute;
}

@keyframes slide {
    from {
        transform: translateX(50vw);
    }

    to {
        transform: translate(-100vw);
    }
}</style>