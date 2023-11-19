<template>
    <div style="height: 100vh; height: 100%; overflow-y: hidden;">
        <iframe :src="cardValue" class="ya-frame" frameborder="1" allowfullscreen="true"
            style="position: absolute"></iframe>
        <div class="route-block"  :class="isRollUp ? 'cards hidden':'cards showing'" v-if="!props.hideElements"> 
            <div class="d-flex justify-content-between m-3 mb-4 mt-5 navigation px-6">
                <v-btn-toggle v-model="toggle" divided theme="dark" class="float-left">
                    <v-btn value="1">Маршруты</v-btn>
                    <v-btn value="2">Локации</v-btn>
                </v-btn-toggle>
                <v-btn theme="dark" v-if="isRollUp" @click="() => isRollUp = !isRollUp">развернуть</v-btn>
                <v-btn theme="dark" v-else @click="() => isRollUp = !isRollUp">свернуть</v-btn>
            </div>
            <component :is="cmp" @showCard="showCard" :isRollUp="isRollUp"/>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed, watch, defineProps, } from "vue";
import { useRoute, useRouter } from 'vue-router';
import LocationCard from "../components/Navigation/LocationCard.vue";
import RoutePointCard from "../components/Navigation/RoutePointCard.vue";
const router = useRouter();
const props = withDefaults(defineProps<{
    hideElements: boolean
}>(), {
    hideElements: false
});

const cmp = computed(() => {
    return toggle.value != 2 ? RoutePointCard : LocationCard;
})
const isRollUp = ref(false);
const showCard = (val: string) => {
    href.value = val;
}
const cardValue = computed(() => {
    return href.value != '' ? href.value : "https://yandex.ru/map-widget/v1";
});
const href = ref("");
const toggle = ref(0)
watch(() => toggle.value, (val, prevVal) => {
    href.value = '';
})

watch(() => props.hideElements, (val, prevVal) => {
    router.replace({path: !val ? "route" : ""})
})
</script>

<style lang="scss" scoped>
.cards {
    overflow-x: hidden;
    overflow-y: hidden;
    transition: height 0.25s ease-in-out;
}
.cards.hidden{
    height: 20em;
}
.cards.showing{
    height: calc(100vh - 70px);
    border-radius: 0;
}

.navigation {
    width: 100%;
}
.ya-frame {
    width: 100%;
    height: 100vh;
    z-index: 10;
}


.route-block {
    width: 100vw;
    position: absolute;
    bottom: 0;
    z-index: 99;
    backdrop-filter: blur(2px);
    background: radial-gradient(rgba(0, 0, 0, 0.1), rgba(0, 0, 0, 0.2));
    border-radius: 1em 1em 0 0;
    overflow-y: auto;
}
</style>
