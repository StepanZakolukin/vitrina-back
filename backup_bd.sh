#!/bin/bash

if [ $# -ne 3 ]; then
    echo "Этот скрипт принимает на вход три аргумента: название окружения, имя базы данных и имя пользователя базы данных."
    echo "Этот скрипт выполняет бэкап базы данных в формате .dump."
    exit 1
fi

ENV_NAME=$1
PG_NAME=$2
PG_USER=$3

# Имя контейнера БД
CONTAINER_NAME=vitrina-db-${ENV_NAME}

# Путь к целевому бэкапу
BACKUP_PATH=~/${ENV_NAME}/backup/backup.dump

echo "[ $(date '+%Y-%m-%d %H:%M') ] Starting backup for $ENV_NAME"

# Команда: сохранить один файл, перезаписывая старый
docker exec "$CONTAINER_NAME" pg_dump -U "$PG_USER" -F c "$PG_NAME" > "$BACKUP_PATH"

if [ $? -eq 0 ]; then
  echo "[ OK ] Backup for $ENV_NAME saved to $BACKUP_PATH"
else
  echo "[ ERROR ] Backup for $ENV_NAME failed"
fi
