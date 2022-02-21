<template>
  <div class="game-main">
      <div class="row">
        <div class="brd owner">Ведущий</div>
        <div class="column">
            <questions-grid v-if="gameState.currentState==0" class="brd gamescene" :roundUid="roundUid"></questions-grid>
            <question-component v-if="gameState.currentState==1" class="brd gamescene" :questionUid="gameState.currentQuestionUid"></question-component>
            <div class="row">
                <div class="brd player">Игрок 1</div>
                <div class="brd player">Игрок 2</div>
                <div class="brd player">Игрок 3</div>
            </div>
        </div>
        <div class="brd gamemenu">Меню</div>
      </div>
  </div>
</template>

<script>
import QuestionsGrid from './QuestionsGrid.vue'

import { gameState } from '../state/gameState.js'
import QuestionComponent from './QuestionComponent.vue';

export default {
  components: { QuestionsGrid, QuestionComponent },
  name: 'GameMain',
  props: ["lobbyUid", "userUid"],
  watch: {
    lobbyUid(newUid) {
      if (newUid != "-1") {
        this.roundUid = 'a8ab167e-2c35-4dbc-9b91-1b8e9ea7df9d';
      }
    }
  },
  data() {
      return {
          roundUid: '-1',
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
 .game-main {
  height: 100%;
  width: 100%
 }
 .row {
     display: flex;
    flex-direction: row;
    flex: 1;
    height: 100%
 }
 .column {
     display: flex;
    flex-direction: column;
    flex: 1;
 }
 .player {
     display: flex;
     min-height: 100px;
     max-height: 100px;
 }
 .gamescene {
    display: flex;
    min-width: 100%;
    min-height: 85%
 }
 .owner {
     display: flex;
    flex: 0.2;
 }
 .gamemenu {
     display: flex;
    flex: 0.2;
 }
</style>
