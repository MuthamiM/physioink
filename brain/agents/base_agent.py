from abc import ABC, abstractmethod

class BaseAgent(ABC):
    @abstractmethod
    def run(self, temperature: float = 0.5, context: str = None) -> str:
        """Execute the agent logic."""
        pass

class DummyAgent(BaseAgent):
    def run(self, context: str) -> str:
        return f"Processed: {context}"
