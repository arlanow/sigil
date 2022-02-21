import { reactive } from 'vue'

export const gameState = reactive({
  currentState: 0,
  currentQuestionUid: '-1'
})