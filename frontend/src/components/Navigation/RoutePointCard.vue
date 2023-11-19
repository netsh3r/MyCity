<script setup lang="ts">
import { ref, defineEmits } from "vue";
import axios from 'axios';
import router from "@/router";
const routes = ref<{ id: number }[]>([]);
const emit = defineEmits(['showCard'])
const loadData = async () => {
    routes.value = (await axios.get('Route/List'))?.data ?? [];
}

const showRoute = async (routeId: number) => {
    const routeData = (await axios.get(`/Route/Get?id=${routeId}`)).data;
    emit('showCard', `https://yandex.ru/map-widget/v1/?rtext=${routeData.routePointDto.map(i => `${i.location.point.x}%2C${i.location.point.y}`).join('~')}`);
}

const openRoute = (routeId: number) => {
    router.push({
        path: 'routePoint',
        query: {
            id: routeId
        }
    });
}

const route = ref("");
loadData();
</script>

<template>
    <div class="d-flex flex-wrap mx-2">
        <v-card :title="t.name" class="m-2 route-card" v-for="t in routes" :key="t.id" width="25em" height="11em" theme="dark">
            <v-card-text class="route-card-text">{{ t.description }}</v-card-text>
            <template #actions>
                <v-btn variant="tonal" @click="showRoute(t.id)">Отобразить</v-btn>
                <v-btn variant="tonal" @click="openRoute(t.id)">открыть маршрут</v-btn>
            </template>
        </v-card>
    </div>
</template>

<style scoepd>
.route-card {
    background:
        linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)),
        url("@/assets/imgs/test.png") !important;
    background-size: cover;
    background-repeat: no-repeat;
    background-attachment: fixed;
    background-position: top;
}

.route-card-text {
    height: 62px;
    display: -webkit-box;
    -webkit-line-clamp: 3;
    -webkit-box-orient: vertical;
    overflow: hidden;
}
</style>