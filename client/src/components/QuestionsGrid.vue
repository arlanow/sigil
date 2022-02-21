<template>
  <div class="container">
    <div class="row" v-for="theme in roundInfo" :key="theme.theme">
      <div class="title">{{theme.theme}}</div> <button class="brd" v-for="question in theme.questions" :key="question.cost" @click="() => {gameState.currentState = 1; gameState.currentQuestionUid = question.uid}">{{question.cost}}</button>
    </div>
  </div>
</template>

<script>
import { gameState } from '../state/gameState.js'

export default {
  name: 'GameMain',
  props: ["roundUid"],
  watch: {
    roundUid: {
      handler(newUid) {
        if (newUid != '-1') this.getRoundInfo(newUid)
      },
      immediate: true
    }
  },
  methods: {
    async getRoundInfo(rounduid) {
        const res = await fetch('https://localhost:7094/RoundInfo/'+rounduid)
        this.roundInfo = await res.json()
    }
  },
data() {
  return {
    roundInfo: [],
    gameState
  }
}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
 .brd {
   display: flex;
   border: 1px solid black;
   flex: 1;
   justify-content: center;
 }
 .row {
   display: flex;
    flex-direction: row;
    flex: 1;
 }
 .title {
   border: 1px solid black;
   display: flex;
   flex: 3;
 }
 .container {
   display: flex;
   flex-direction: column;
 }
</style>
