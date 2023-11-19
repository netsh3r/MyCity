<script setup lang="ts">
import { ref, defineEmits, defineProps } from "vue"
import axios from "axios";
import router from "@/router";

const props = defineProps<{
    isRollUp: boolean
}>()
const emit = defineEmits(['showCard'])
const locations = ref<{
    id: number
}[]>()
const loadData = async () => {
    locations.value = (await axios.post("api/Location/List")).data;
}

const showLocation = async (locationId: number) => {
    var result = (await axios.get(`/api/Location/GetLocation/${locationId}`)).data;
    emit('showCard', result.href);
}
const openLocation = (locationId: number) => {
    router.push({
        path: 'locationCard',
        query: {
            id: locationId
        }
    });
}

loadData();
</script>

<template>
    <div class="d-flex flex-wrap mx-2">
        <v-card class="m-2" v-for="t in locations" :key="t.id" theme="dark" width="27em">
            <div class="location-card-img" v-show="!props.isRollUp" ></div>
            <v-card-item>
                <v-card-title>{{ t.name }}</v-card-title>
                <v-card-text class="route-card-text">{{ t.description }}</v-card-text>
            </v-card-item>
            <template #actions>
                <v-btn variant="tonal" @click="showLocation(t.id)">Отобразить локацию</v-btn>
                <v-btn variant="tonal" @click="openLocation(t.id)">открыть локацию</v-btn>
            </template>
        </v-card>
    </div>
</template>

<style scoped>
.location-card-img {
    width: 100%;
    height: 500px;
    background:
        linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)),
        url("../../assets/imgs/test.png") !important;
}
</style>