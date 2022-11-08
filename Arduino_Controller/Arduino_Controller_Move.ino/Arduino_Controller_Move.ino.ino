/* Constantes pour les broches */
const byte TRIGGER_PIN_1 = 2; // Broche TRIGGER
const byte ECHO_PIN_1 = 3;    // Broche ECHO

/* Constantes pour les broches */
const byte TRIGGER_PIN_2 = 4; // Broche TRIGGER
const byte ECHO_PIN_2 = 5;    // Broche ECHO 
 
/* Constantes pour le timeout */
const unsigned long MEASURE_TIMEOUT = 100000UL; // 25ms = ~8m à 340m/s

/* Vitesse du son dans l'air en mm/us */
const float SOUND_SPEED = 340.0 / 1000;


/** Fonction setup() */
void setup() {
   
  /* Initialise le port série */
  Serial.begin(9600);
   
  /* Initialise les broches */
  pinMode(TRIGGER_PIN_1, OUTPUT);
  digitalWrite(TRIGGER_PIN_1, LOW); // La broche TRIGGER doit être à LOW au repos

  pinMode(TRIGGER_PIN_2, OUTPUT);
  digitalWrite(TRIGGER_PIN_2, LOW); // La broche TRIGGER doit être à LOW au repos

  pinMode(ECHO_PIN_1, INPUT);
  pinMode(ECHO_PIN_2, INPUT);
}
 
/** Fonction loop() */
void loop() {
  
  /* 1. Lance une mesure de distance en envoyant une impulsion HIGH de 10µs sur la broche TRIGGER */
  digitalWrite(TRIGGER_PIN_1, HIGH);
  delayMicroseconds(10);
  digitalWrite(TRIGGER_PIN_1, LOW);
 
  /* 2. Mesure le temps entre l'envoi de l'impulsion ultrasonique et son écho (si il existe) */
  long measure1 = pulseIn(ECHO_PIN_1, HIGH, MEASURE_TIMEOUT);

  
  digitalWrite(TRIGGER_PIN_2, HIGH);
  delayMicroseconds(10);
  digitalWrite(TRIGGER_PIN_2, LOW);
  long measure2 = pulseIn(ECHO_PIN_2, HIGH, MEASURE_TIMEOUT);
   
  /* 3. Calcul la distance à partir du temps mesuré */
  float distance_mm_1 = measure1 / 2.0 * SOUND_SPEED;
  float distance_mm_2 = measure2 / 2.0 * SOUND_SPEED;
  /* Affiche les résultats en mm, cm et m */
  Serial.print(distance_mm_1 / 10.0, 2);
  Serial.print(":");
  Serial.println(distance_mm_2 / 10.0, 2);

   
  /* Délai d'attente pour éviter d'afficher trop de résultats à la seconde */
  delay(50);
}
