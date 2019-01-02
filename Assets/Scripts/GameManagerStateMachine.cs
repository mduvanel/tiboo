using System;
using System.Collections.Generic;

namespace Tiboo
{
    public class GameManagerStateMachine
    {
        public enum State
        {
            PLAYING_SOUNDS,
            WAIT_FOR_INPUT
        }

        public enum Event
        {
            INPUT_RECEIVED,
            SOUND_FINISHED
        }

        public class StateTransition
        {
            readonly State m_currentState;
            readonly Event m_event;

            public StateTransition(State currentState, Event currentEvent)
            {
                m_currentState = currentState;
                m_event = currentEvent;
            }

            public override int GetHashCode()
            {
                return 17 + 31 * m_currentState.GetHashCode() + 31 * m_event.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                StateTransition other = obj as StateTransition;
                return other != null &&
                    m_currentState == other.m_currentState &&
                    m_event == other.m_event;
            }
        }

        Dictionary<StateTransition, State> m_transitions;
        public State CurrentState { get; private set; }

        public GameManagerStateMachine()
        {
            CurrentState = State.PLAYING_SOUNDS;
            m_transitions = new Dictionary<StateTransition, State>
            {
                { new StateTransition(State.WAIT_FOR_INPUT, Event.INPUT_RECEIVED), State.PLAYING_SOUNDS },
                { new StateTransition(State.PLAYING_SOUNDS, Event.SOUND_FINISHED), State.WAIT_FOR_INPUT }
            };
        }

        public State GetNext(Event currentEvent)
        {
            StateTransition transition = new StateTransition(CurrentState, currentEvent);
            State nextState;
            if (!m_transitions.TryGetValue(transition, out nextState))
                throw new Exception("Invalid transition: " + CurrentState + " -> " + currentEvent);
            return nextState;
        }

        public State MoveNext(Event currentEvent)
        {
            CurrentState = GetNext(currentEvent);
            return CurrentState;
        }
    }
}
