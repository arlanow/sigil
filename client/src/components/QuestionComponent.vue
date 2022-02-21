<template>
  <div class="question" @click="() => gameState.currentState = 0">
    {{question.question}}
  </div>
</template>

<script>
import { gameState } from '../state/gameState.js'

export default {
  name: 'QuestionComponent',
  props: ['questionUid'],
  watch: {
    questionUid: {
      handler(newUid) {
        if (newUid != '-1') this.getQuestionInfo(newUid)
      },
      immediate: true
    }
  },
  methods: {
    async getQuestionInfo(questionUid) {
        const res = await fetch('https://localhost:7094/Question/'+questionUid)
        this.question = await res.json()
    }
  },
  data() {
  return {
    question: {},
    gameState
  }
}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
