
<template>
  <div class="maximal column">
    <button v-for="item in items" :key="item.uid" @click="() => lobbyUid = 'test'">{{item.title}}</button>
    <li v-for="r in rounds" :key="r.uid">
    {{ r.title}}
    </li>
    <game-main :lobbyUid="lobbyUid"></game-main>
  </div>
</template>

<script>
import GameMain from './components/GameMain.vue';

export default {
  name: 'App',
  components: {
    GameMain
  },
  async created() {
  const response = await fetch("https://localhost:7094/Pack");
  const data = await response.json();
  this.items = data;

  const question_response = await fetch("https://localhost:7094/Question/7ece74a5-9a6e-43e7-9f05-5f11cb5fd4eb");
  const question_data = await question_response.json();
  this.question = question_data;
},
watch: {
    currentPack(newUid) {
      if (newUid != "-1") {
        this.getRounds(newUid)
      }
    }
  },
  methods: {
    async getRounds(packuid) {
        const res = await fetch('https://localhost:7094/PackInfo/Round/'+packuid)
        this.rounds = await res.json()
    }
  },
data() {
  return {
    items: [],
    rounds: [],
    currentPack: "-1",
    question: {},
    lobbyUid: '-1'
  } 
}
  //created() {
  //  items = [{"title": "test"}]
  //}
}

</script>

<style>
#app {
  height: 100%;
  width: 100%
}
game-main {
  height: 100%;
  width: 100%
}
.maximal {
  height: 100%;
  width: 100%
}
</style>
